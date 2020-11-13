import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();

export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);
    const [produtosTop, setProdutosTop] = useState([]);

    const consulte = async () => {
        try {
            const resp = await api.relatoriosTopProdutos();
            setProdutosTop(resp);
        } catch (e) {
            toast.error(e.response.data.mensagem)
        }
    }

    useEffect(() => {
        consulte();
      }, []);

    return(
        <div className="eiei">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Relatorio", state: infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
            </div>


            <div class="tabela1">
                <div className="shit1">
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Nome</th>
                                <th>Qtd. Anunciadas</th>
                                <th>Total Comprado</th>
                            </tr>
                        </thead>

                        <tbody>
                            {produtosTop.map(x =>
                            <tr>
                                <td>{x.nome}</td>
                                <td>{x.qtdAnunciada}</td>
                                <td>{x.totalComprado}</td>
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