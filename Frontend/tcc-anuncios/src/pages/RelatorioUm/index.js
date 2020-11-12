import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);
    const [anunciosDia, setAnunciosDia] = useState([]);

    const anunciosPorDia = async () => {
        const resp = await api.anunciosDia();
        setAnunciosDia(resp);
    }

    useEffect(() => {
        anunciosPorDia();
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
                                <th>Dia</th>
                                <th>Cliente</th>
                                <th>Tipo de Produto</th>
                                <th>Preço</th>
                            </tr>
                        </thead>

                        <tbody>
                            {anunciosDia.map(x =>
                                <tr>
                                    <td>{x.dia.substring(0,10)}</td>
                                    <td>{x.cliente}</td>
                                    <td>{x.tipoProduto}</td>
                                    <td>{x.preco}</td>
                                </tr>
                            )}    
                        </tbody>
                    </table>
                </div>
            </div>

            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}