import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

const api = new anuncioAPI();


export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);
    const [mesI, setMesI] = useState(1);
    const [mesF, setMesF] = useState(1);
    const [anunciosMes, setAnunciosMes] = useState([]);

    const anunciosPorMes = async () => {
        try {
            const resp = await api.anunciosMes(Number(mesI), Number(mesF));
            setAnunciosMes(resp);
            console.log(resp)
        } catch (e) {
            toast.error(e.response.data.mensagem);
        }
    }

    return(
        <div className="eiei">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Relatorio", state: infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
            </div>

            <div className="InputsRelatoriosPorMes">

                <label className="labelRelatorio">
                    Mês inicial
                    <select value={mesI} onChange={(e) => setMesI(e.target.value)} type="number" className="form-control">
                        <option value="01">Janeiro</option>
                        <option value="02">Fevereiro</option>
                        <option value="03">Março</option>
                        <option value="04">Abril</option>
                        <option value="05">Maio</option>
                        <option value="06">Junho</option>
                        <option value="07">Julho</option>
                        <option value="08">Agosto</option>
                        <option value="09">Setembro</option>
                        <option value="10">Outubro</option>
                        <option value="11">Novembro</option>
                        <option value="12">Dezembro</option>
                    </select>
                </label>

                <label className="labelRelatorio">
                    Mês final
                    <select value={mesF} onChange={(e) => setMesF(Number(e.target.value))} type="number" className="form-control">
                        <option value="01">Janeiro</option>
                        <option value="02">Fevereiro</option>
                        <option value="03">Março</option>
                        <option value="04">Abril</option>
                        <option value="05">Maio</option>
                        <option value="06">Junho</option>
                        <option value="07">Julho</option>
                        <option value="08">Agosto</option>
                        <option value="09">Setembro</option>
                        <option value="10">Outubro</option>
                        <option value="11">Novembro</option>
                        <option value="12">Dezembro</option>
                    </select>
                </label>

                <button onClick={anunciosPorMes} className="fas fa-search">Filtrar</button>
          </div>


            <div class="tabela1">
                <div className="shit1">
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Mês</th>
                                <th>Qtd. Anuncios</th>
                                <th>Total Anuncios</th>
                            </tr>
                        </thead>

                        <tbody>
                            {anunciosMes.map(x =>
                                <tr>
                                    <td>{x.mes}</td>
                                    <td>{x.qtdAnuncios}</td>
                                    <td>{x.somaDosPrecoDosAnuncios}</td>
                                    <td>{x.totalVendido}</td>
                                </tr>
                            )}      
                        </tbody>
                    </table>
                </div>
            </div>
            <ToastContainer/>
            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}